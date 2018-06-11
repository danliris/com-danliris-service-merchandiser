docker build -f Dockerfile.test.build -t com-danliris-service-merchandiser-webapi:test-build .
docker create --name com-danliris-service-merchandiser-webapi-test-build com-danliris-service-merchandiser-webapi:test-build
mkdir bin
docker cp com-danliris-service-merchandiser-webapi-test-build:/out/. ./bin/publish
docker build -f Dockerfile.test -t com-danliris-service-merchandiser-webapi:test .