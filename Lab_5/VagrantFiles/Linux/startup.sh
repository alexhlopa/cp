cd /var/lab5/
dotnet dev-certs https
sudo kill -9 $(sudo lsof -t -i:5000)
dotnet CrossPlatformLab5.dll --urls https://*:5000