all:
	dotnet build
	cp ./bin/Debug/net6.0/WildfrostReptileFaction.dll \
	    C:/Users/artle/AppData/Roaming/r2modmanPlus-local/Wildfrost/profiles/Default/BepInEx/plugins/Unknown-WildfrostReptileFaction/WildfrostReptileFaction.dll
	cp -r ./assets \
	    C:/Users/artle/AppData/Roaming/r2modmanPlus-local/Wildfrost/profiles/Default/BepInEx/plugins/Unknown-WildfrostReptileFaction
	echo "Done!"

clean:
	dotnet clean

super-clean:
	dotnet clean
	rm -drv obj