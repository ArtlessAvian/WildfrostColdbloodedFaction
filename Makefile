all:
	dotnet build
	cp ./bin/Debug/net6.0/WildfrostReptileFaction.dll \
	    C:/Users/artle/AppData/Roaming/r2modmanPlus-local/Wildfrost/profiles/Default/BepInEx/plugins/Unknown-WildfrostReptileFaction/WildfrostReptileFaction.dll
	cp -r ./assets \
	    C:/Users/artle/AppData/Roaming/r2modmanPlus-local/Wildfrost/profiles/Default/BepInEx/plugins/Unknown-WildfrostReptileFaction
	echo "Done!"

copy-lib-from-bepinex:
	diff -qsN 'C:/Users/artle/AppData/Roaming/r2modmanPlus-local/Wildfrost/profiles/Default/BepInEx/interop/assembly-hash.txt' \
		lib/assembly-hash.txt
	find 'C:/Users/artle/AppData/Roaming/r2modmanPlus-local/Wildfrost/profiles/Default/BepInEx/interop' \
		-name *.dll \
		-exec cp -uv {} ./lib \;
	cp -uv 'C:/Users/artle/AppData/Roaming/r2modmanPlus-local/Wildfrost/profiles/Default/BepInEx/interop/assembly-hash.txt' \
		lib/assembly-hash.txt

clean:
	dotnet clean

super-clean:
	dotnet clean
	rm -drv obj