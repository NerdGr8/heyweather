#!/bin/bash

echo "--------------------------------------------------------------------"
echo "--------------------------------------------------------------------"
echo "--------------------------------------------------------------------"
echo "------------  NM - Build automation   ----------"
echo "------------  Building, commiting and pushing containers  ----------"
echo "--------------------------------------------------------------------"
echo "--------------------------------------------------------------------"
echo "--------------------------------------------------------------------
"
CURRENTFOLDER=`pwd`
RootSrc="$CURRENTFOLDER/src"

echo $'\e[1;34m'"------------------- Building .net projects------------------------

# "$'\e[0m'
#docker container prune

sudo rm -rf "$RootSrc/HeyWeather/out"
sudo docker build -t 363709968092.dkr.ecr.us-east-1.amazonaws.com/misc-images/heyweather.dev "$RootSrc/HeyWeather/"
docker push 363709968092.dkr.ecr.us-east-1.amazonaws.com/misc-images/heyweather.dev

echo $'\e[1;34m'"------------------- Done running resources ------------------------
"$'\e[0m'