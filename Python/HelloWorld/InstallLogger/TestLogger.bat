@echo OFF

set logfile=Logger.txt

python InstallLogger.py ACMMaster.bat INFO "Welcome To Chiri, by Baiju Mathew" %logfile%
python InstallLogger.py ACMMaster.bat INFO "Today Its going to rain errors" %logfile%
python InstallLogger.py ACMMaster.bat WARN "Be ready!!" %logfile%
python InstallLogger.py ACMMaster.bat ERROR "Shrrrrrrrrrrrr!!" %logfile%
python InstallLogger.py ACMMaster.bat CRITICAL "This master is not good. Please remaster !!" %logfile%

python InstallLogger.py ACMMaster.bat INFO "This log is really good" %logfile%
python InstallLogger.py ACMMaster.bat INFO "This will help in seeing the errors quickly" %logfile%

python InstallLogger.py RDF.exe ERROR "RDF Error found. Please check .err files in the build drive. This is because the syntax of the rdf file may have gone bad." %logfile%
