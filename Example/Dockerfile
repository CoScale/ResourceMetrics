FROM ubuntu:16.04

EXPOSE 5000

LABEL com.coscale.monitoring='[{"PluginType":"NETCORE","Configuration":{"STATS URL":["http://localhost:5000/metrics"],"URL CHECK":["http://localhost:5000/api/values/"]}}]'

COPY metrics.patch /tmp/metrics.patch

RUN apt-get update && apt-get install -y curl apt-transport-https patch && \

    ## Install .NET core
    curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > /etc/apt/trusted.gpg.d/microsoft.gpg  && \
    echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-xenial-prod xenial main" > /etc/apt/sources.list.d/dotnetdev.list && \
    apt-get update && apt-get install -y dotnet-sdk-2.0.2 && \

    ## Create an example WebApp
    dotnet new webapi -o WebApp1 && \
    cd WebApp1 && \
    patch -p1 < /tmp/metrics.patch && \

    ## Build the WebApp
    dotnet restore && \
    dotnet build

CMD [ "/usr/bin/dotnet", "/WebApp1/bin/Debug/netcoreapp2.0/WebApp1.dll" ]
