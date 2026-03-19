######################################
#           Configurations
######################################

receptors=~/Git/GenericComputationPlatform/DockingApiService/Workspace/Receptors
wwwroot=~/Git/GenericComputationPlatform/GenericComputationPlatform/wwwroot

######################################
#              Scripts
######################################

clear

cd $receptors
mkdir -p $wwwroot/models $wwwroot/images/l $wwwroot/images/m $wwwroot/images/s

ok=0
skipped=0

for i in */*/*/;
do
	i=${i%/};
	echo $i;

	rec=${i%/*};
	cav=${rec#*/};
	rec=${rec%/*};
	mod=${i#*/*/};

	############# models #############

	out=$wwwroot/models/${rec}-${cav}-${mod}.mol2;
	if ! test -f $out;
	then
		cp $i/AminoAcids.mol2 $out;
		ok=$((ok+1));
	else
		skipped=$((skipped+1));
	fi;

	out=$wwwroot/models/${rec}-${cav}-${mod}-pocket.mol2;
	if ! test -f $out;
	then
		cp $i/Pocket.mol2 $out;
		ok=$((ok+1));
	else
		skipped=$((skipped+1));
	fi;

	############# renderings #############

	for settings in l,1024 m,512 s,256;
	do
		profile=${settings%,*};
		height=${settings#*,};
		out=$wwwroot/images/$profile/${rec}-${cav}-${mod}.png;

		if ! test -f $out;
		then
			ffmpeg -hide_banner -i $i/Rendering.png -vf scale=-1:$height $out -y 2> /dev/null;
			ok=$((ok+1));
		else
			skipped=$((skipped+1));
		fi;
	done;
done;

echo Created $ok, skipped $skipped;