@echo OFF

python InstallLogger.py ACMMaster.bat INFO "Welcome To Chiri, by Baiju Mathew"
python InstallLogger.py ACMMaster.bat INFO "Today Its going to rain errors"
python InstallLogger.py ACMMaster.bat WARN "Be ready!!"
python InstallLogger.py ACMMaster.bat ERROR "Shrrrrrrrrrrrr!!"
python InstallLogger.py ACMMaster.bat CRITICAL "This master is not good. Please remaster !!"

python InstallLogger.py ACMMaster.bat INFO "This log is really good"
python InstallLogger.py ACMMaster.bat INFO "This will help in seeing the errors quickly"

python InstallLogger.py RDF.exe ERROR "RDF Error found. Please check .err files in the build drive. This is because the syntax of the rdf file may have gone bad."
