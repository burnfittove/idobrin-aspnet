#!/bin/bash

if [ $# -eq 0 ]
then
	echo "No migration name provided."
	echo "You must enter a migration name."
	exit 1
fi

echo "Making migration $1..."
exec dotnet ef migrations add $1 --project idobrin-aspnet-dal --startup-project idobrin-aspnet-api
exit 0
