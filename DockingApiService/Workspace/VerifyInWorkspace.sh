clear

for i in $(cat Proteins.csv | cut -d',' -f1 | tail -n+2);
do
	echo $i;

	# 12 files: model and configuration for computing docking scores
	for j in 1 2 3;
	do
		ls ${i}/${i}_model_${j}.conf > /dev/null;
		ls ${i}/${i}_model_${j}.mol2 > /dev/null;
		ls ${i}/${i}_model_${j}-protomol.mol2 > /dev/null;
		ls ${i}/${i}_model_${j}.pdbqt > /dev/null;
	done;

	# 3 folders: ligand pdbqts input, locks and output
	ls ${i}/Ligands > /dev/null;
	ls ${i}/Locks > /dev/null;
	ls ${i}/Output > /dev/null;

	# 1 file: fingerprints
	ls ${i}/${i}_Fingerprints.fp2 > /dev/null;

	# 1 file: docking scores for ligands
	ls ${i}/${i}_ScoresSummary.csv > /dev/null;
	
	# 1 file: ligands for computing docking score
	ls ${i}/${i}_ProvisionedLigands.csv > /dev/null;

	# 4 files: bio activity
	ls ${i}/${i}_EC50.txt > /dev/null;
	ls ${i}/${i}_IC50.txt > /dev/null;
	ls ${i}/${i}_Ki.txt > /dev/null;
	ls ${i}/${i}_BioActivity.csv > /dev/null;

	# 2 files: 3d images
	for j in 2 3;
	do
		ls ${i}/${i}_model_${j}.png > /dev/null;
	done;
done;