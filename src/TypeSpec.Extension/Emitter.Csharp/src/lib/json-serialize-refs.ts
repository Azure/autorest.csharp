export function createNewRefs(obj: any) : any{
    const map = new Map<object, string>();

    
}

export function createRefs(obj: any) : any {
  const map = new Map<object, string>();

  function sweep(val: any): any {
    if (typeof val === "object" && val !== null) {
      const id = String(map.size + 1);

      if (Object.prototype.toString.apply(val) === "[object Array]") { // ARRAY
              const marr = [];
              for (let i = 0; i < val.length; ++i) {
                const V = val[i];
                const backRef = map.get(V);
                if (backRef) {
                  marr[i] = {
                    $ref: backRef,
                  };
                } else {
                  marr[i] = sweep(V);
                }
              }
              return marr;
      } else { // OBJECT

        if (val instanceof Date) {
          return val;
        } else {
          map.set(val, id);

          const mobj: any = { $id: id };

          for (const name in val) {
            if (Object.prototype.hasOwnProperty.call(val, name)) {
              const V = val[name];
              const backRef = map.get(V);
              if (backRef) {
                mobj[name] = {
                  $ref: backRef,
                };
              } else {
                mobj[name] = sweep(V);
              }
            }
          }

          return mobj;
        }
      }
    }
    return val; // PRIMITIVE
  }

  const res = sweep(obj);

  return res;
}

/** convert given obj to json resolving references as specified by preserveType ( NewtonJson NET compatible ) */
export function stringifyRefs(obj: any, replacer?: (this: any, key: string, value: any) => any, space?: string | number) {
  return JSON.stringify(createRefs(obj), replacer, space);
}
