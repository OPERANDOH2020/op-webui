# I take a official mono image https://hub.docker.com/_/mono/
# we choose normal 
FROM mono:3.10

RUN mkdir -p /usr/src/app/source /usr/src/app/build
WORKDIR /usr/src/app/source

COPY AdministrationConsole/. /usr/src/app/source

WORKDIR /usr/src/app/build

EXPOSE 80






