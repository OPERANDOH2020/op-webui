# I take a official mono image https://hub.docker.com/_/mono/
# we choose normal 
FROM mono:4.6.1.3

RUN mkdir -p /usr/src/app/source /usr/src/app/build
WORKDIR /usr/src/app/source

COPY AdministrationConsole/. /usr/src/app/source

RUN nuget restore -NonInteractive
RUN nuget update -self
#RUN xbuild /property:Configuration=Release /property:OutDir=/usr/src/app/build/

WORKDIR /usr/src/app/build

#EXPOSE 80
#EXPOSE 5000

#CMD [ "mono",  "./Operando-AdministrationConsole.exe", "--no-daemon" ]











