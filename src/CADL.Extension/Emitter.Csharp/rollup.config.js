import nodeResolve from '@rollup/plugin-node-resolve';
import commonjs from '@rollup/plugin-commonjs'

export default {
    input: ["./dist/src/index.js"],
    output: {
        file: "./dist/bundle.js",
        format: "es",
    },
    plugins: [nodeResolve(), commonjs()],
    external: ["@cadl-lang/compiler", "@cadl-lang/openapi", "@cadl-lang/rest"]
};
