clear

cd ..

for i in $(cat Content/Proteins.csv | cut -d',' -f1,3 | tail -n+2);
do
	echo $i;
	old=${i%,*};
	new=${i#*,};

	if [ "$old" == "$new" ];
	then
		continue;
	fi;

	p=Scripts
	mv $p/SVM_model_${old}.m $p/SVM_model_${new}.m > /dev/null;

	p=wwwroot/models
	mv $p/$old/${old}_model_1.mol2 $p/$old/${new}_model_1.mol2 > /dev/null;
	mv $p/$old/${old}_model_1-protomol.mol2 $p/$old/${new}_model_1-protomol.mol2 > /dev/null;
	mv $p/$old/${old}_model_2.mol2 $p/$old/${new}_model_2.mol2 > /dev/null;
	mv $p/$old/${old}_model_2-protomol.mol2 $p/$old/${new}_model_2-protomol.mol2 > /dev/null;
	mv $p/$old/${old}_model_3.mol2 $p/$old/${new}_model_3.mol2 > /dev/null;
	mv $p/$old/${old}_model_3-protomol.mol2 $p/$old/${new}_model_3-protomol.mol2 > /dev/null;

	mv $p/$old $p/$new > /dev/null;

	p=wwwroot/images
	mv $p/l/${old}_model_2.png $p/l/${new}_model_2.png > /dev/null;
	mv $p/l/${old}_model_3.png $p/l/${new}_model_3.png > /dev/null;
	mv $p/m/${old}_model_2.png $p/m/${new}_model_2.png > /dev/null;
	mv $p/m/${old}_model_3.png $p/m/${new}_model_3.png > /dev/null;
	mv $p/s/${old}_model_2.png $p/s/${new}_model_2.png > /dev/null;
	mv $p/s/${old}_model_3.png $p/s/${new}_model_3.png > /dev/null;
done;