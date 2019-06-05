docker run -d -p 8443:8443 -v "$(pwd)/swagger:/opt/imposter/config" outofcoffee/imposter-openapi
npm install -g http-server
http-server -p 8085 &
