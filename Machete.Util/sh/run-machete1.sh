#!/bin/bash

# ./Machete.Util/sh/run-machete1.sh
# This script runs the Machete.Web.dll binary inside a container behind an NginX proxy, which tests the creation of the container. Not needed for development.


# trap "{ rm -f machete1env.list; }" EXIT

docker rm machete1

clear

echo "RUN-MACHETE1.SH"
echo ""
echo "This file is for running the latest Machete container with all its secrets declared in a development environment."
echo "Currently, in order to run the container in a production environment, you will have to provision the secrets"
echo "manually."
echo ""
echo "To run NginX and Machete together, type:"
echo ""
echo "  ./machete.sh"
echo ""
echo "...and then if you want to return to the previous shell, key chord Ctrl-P + Ctrl+Q and the container will"
echo "continue to run in the background. Alternatively, to stop the process and the container, key Ctrl-C + Ctrl-D."
echo ""

# READ https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/index?view=aspnetcore-2.2#environment-variables-configuration-provider
dotnet user-secrets list --project=Machete.Web \
  | sed s/[[:space:]]//g \
  | sed s/:/__/g \
  | sed s/Authentication/MACHETE_Authentication/g \
  >> machete1env.list

# TODO get latest tag from GitHub
docker run -it --name machete1 --network machete-bridge -p 443:443 --env-file machete1env.list ndlonmachete/debian:latest
