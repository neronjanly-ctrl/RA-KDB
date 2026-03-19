clear

cd ..

ls Workspace/Prediction/Prediction.py > /dev/null;
ls Workspace/Docking.db > /dev/null;
ls Workspace/Hangfire.db > /dev/null;
ls Workspace/Proteins.csv > /dev/null;

for i in $(cat Workspace/Proteins.csv | cut -d',' -f1 | tail -n+2);
do
	echo $i;

	###################################################
	# verify existence of trained models (4 files)
	###################################################
	p=Workspace/Prediction
	ls $p/LR_model_$i.m > /dev/null;
	ls $p/MLP_model_$i.m > /dev/null;
	ls $p/RF_model_$i.m > /dev/null;
	ls $p/SVM_model_$i.m > /dev/null;

	###################################################
	# verify existence of protein receptors and
	# configuration files (1 folder + 7 files)
	###################################################
	p=Workspace/Receptors

	for j in 1 2 3;
	do
		ls $p/${i}/${i}_model_$j.conf > /dev/null;
		ls $p/${i}/${i}_model_$j.pdbqt > /dev/null;
	done;

	ls $p/${i}/${i}_Fingerprints.fp2> /dev/null;

	###################################################
	# verify existence of protein models (1 folder + 6 files)
	###################################################
	p=wwwroot/models/$i
	ls $p > /dev/null;

	for j in 1 2 3;
	do
		ls $p/${i}_model_$j.mol2 > /dev/null;
		ls $p/${i}_model_$j-protomol.mol2 > /dev/null;
	done;

	###################################################
	# verify existence of images (6 files)
	###################################################
	p=wwwroot/images

	for j in l m s;
	do
		ls $p/$j/${i}_model_2.png > /dev/null;
		ls $p/$j/${i}_model_3.png > /dev/null;
	done;
done;