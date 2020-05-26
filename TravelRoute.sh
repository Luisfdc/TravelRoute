#!/bin/bash
echo Foram digitados $# parâmetros. São eles: $*.
echo O primeiro parâmetro foi: $1

cp $1 TravelRoute/TravelRoute.WebApi/Resources
cp $1 TravelRoute/TravelRoute.Repository/Resources

read dir_origem

clear