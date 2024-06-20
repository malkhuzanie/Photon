docker build -t photon . ;
docker tag photon malkhuzanie/photon:latest ;
docker push malkhuzanie/photon:latest ;
docker run -d --rm -p 7023:80 -p 7086:443 \
  -e ASPNETCORE_URLS="https://+;http://+" \
  -e ASPNETCORE_HTTPS_PORTS=7086 \
  -e ASPNETCORE_Kestrel__Certificates__Default__Password="password" \
  -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx \
  -v ${HOME}/.aspnet/https:/https/  \
  --name photon \
  photon
