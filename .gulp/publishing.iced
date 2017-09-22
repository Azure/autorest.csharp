task 'publish-preview', '', [] , (done) ->
  package_path = "#{basefolder}/package.json"
  package_folder = "#{basefolder}"

  # 1. update the patch number
  package_json = require package_path
  
  execute "git rev-list HEAD --count",{cwd:package_folder }, (c, o, e) -> 
    o = o.trim();
    bnum = Number.parseInt( o );
    if (o != "#{bnum}")
      echo "#{ error 'Package Failed:' }  #{error_message "unable to parse build number" }"
      process.exit(1)

    package_json.version = package_json.version.replace /(\d*\.\d*.)(.*)/, "$1#{bnum}" 
    JSON.stringify(package_json,null,'  ').to package_path 

    # 2. call npm publish --tag preview 
    # Note : this will call the npm prepare task, which will call 
    execute "npm publish --tag preview",{cwd:package_folder, silent:false }, (c,o,e) -> 
      echo  "\n\nPublished:  #{package_json.name}@#{info package_json.version} (tagged as @preview)\n\n"
      done()
     