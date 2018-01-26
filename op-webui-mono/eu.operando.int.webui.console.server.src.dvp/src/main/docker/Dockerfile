# I take a official mono image https://hub.docker.com/_/mono/
# we choose normal 
FROM mono:4.6.1.3

RUN apt-get update
RUN apt-get install -y xmlstarlet mono-xsp4 asp.net-examples

RUN mkdir -p /usr/src/app/source /usr/src/app/build
WORKDIR /usr/src/app/source

ADD sources/. /usr/src/app/source
ADD modified/. /usr/src/app/source
ADD adapt_net_to_mono.sh /usr/src/app/source

RUN chmod 750 /usr/src/app/source/adapt_net_to_mono.sh
RUN /usr/src/app/source/adapt_net_to_mono.sh

RUN nuget restore -NonInteractive 
#RUN nuget restore -NonInteractive -PackagesDirectory packages GBE:This is no longer valid as the sln file has been added again 
RUN nuget update -self
RUN xbuild /property:Configuration=Release /property:OutDir=/usr/src/app/build/
 
COPY debian.webapp /etc/xsp4
RUN mkdir -p /etc/mono/registry
RUN chmod uog+rw /etc/mono/registry

WORKDIR /usr/src/app/build

EXPOSE 8084

CMD [ "/usr/bin/xsp4","--port","8084","--address","0.0.0.0","--appconfigdir","/etc/xsp4","--nonstop" ]



