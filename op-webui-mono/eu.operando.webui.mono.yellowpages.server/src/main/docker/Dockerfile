# I take a official mono image https://hub.docker.com/_/mono/
# we choose normal 
FROM mono:4.6.1.3

RUN mkdir -p /usr/src/app/source /usr/src/app/build
WORKDIR /usr/src/app/source

COPY Operando-AdministrationConsole/. /usr/src/app/source

RUN nuget restore -NonInteractive 
#RUN nuget restore -NonInteractive -PackagesDirectory packages GBE:This is no longer valid as the sln file has been added again 
RUN nuget update -self
RUN xbuild /property:Configuration=Release /property:OutDir=/usr/src/app/build/

RUN apt-get update

# opcion xsp4 de paquet repo
RUN apt-get install -y mono-xsp4 asp.net-examples
# RUN service mono-xsp4 start GBE: this does not work

# opcion de xsp4 desde codigo
#RUN apt-get install -y build-essential git autoconf libtool automake monodoc-base git
#RUN git clone https://github.com/mono/xsp.git
#WORKDIR /usr/src/app/source/xsp
#RUN ./autogen.sh
#RUN ./configure -prefix=/usr
#RUN make
#RUN make install

COPY debian.webapp /etc/xsp4
RUN mkdir -p /etc/mono/registry
RUN chmod uog+rw /etc/mono/registry

WORKDIR /usr/src/app/build

EXPOSE 8084

CMD [ "/usr/bin/xsp4","--port","8084","--address","0.0.0.0","--appconfigdir","/etc/xsp4","--nonstop" ]
