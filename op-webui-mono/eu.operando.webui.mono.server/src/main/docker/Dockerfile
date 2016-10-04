# I take a official mono image https://hub.docker.com/_/mono/
# we choose normal 
FROM mono:4.6.1.3

RUN mkdir -p /usr/src/app/source /usr/src/app/build
WORKDIR /usr/src/app/source

COPY Operando-AdministrationConsole/. /usr/src/app/source

RUN nuget restore -NonInteractive
RUN nuget update -self
RUN apt-get update
RUN apt-get install -y git
RUN git clone https://github.com/mono/xsp.git
RUN apt-get install -y build-essential git autoconf libtool automake monodoc-base
RUN cd xsp
RUN ./autogen.sh
RUN ./configure -prefix=/usr
RUN make
RUN make install
#RUN xbuild /property:Configuration=Release /property:OutDir=/usr/src/app/build/

WORKDIR /usr/src/app/build

#EXPOSE 80
#EXPOSE 5000

#CMD [ "mono",  "./Operando-AdministrationConsole.exe", "--no-daemon" ]











