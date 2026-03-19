#!/usr/bin/python3.6
import os
import sys
import numpy as np
import joblib

def make_prediction(models, scores):
	## scores: [docking score 1, docking score 2, docking score 3, similarity score]
	## found the identical compound
	if scores[3] > 0.9999:
		return True, 0.9999

	## no less than 2 docking scores were negative, indicating the compound should be inactive
	if len(list(filter(lambda score: score < 3, scores))) >= 2:   
		return False, 0.9999

	## failed to load models
	if models == None:
		return (scores[3] > 0.85 or np.average(np.array([scores[0:3]])) > 6.00), None

	pl = list(map(lambda model: model.predict_proba(np.array([scores]))[0][1], models))    ## probability list
	prob_active = pl[0] * pl[1] * pl[2] + pl[0] * pl[1] * (1 - pl[2]) + pl[0] * pl[2] * (1 - pl[1]) + pl[1] * pl[2] * (1 - pl[0])

	if prob_active >= 0.5:
		return True, prob_active

	return False, 1 - prob_active

if __name__ == "__main__":
	target_name = sys.argv[1]
	url_iter = map(lambda model_type: "./" + target_name + "/Model_" + model_type + ".m", ["LR", "RF", "SVM"])
	url_list = list(filter(lambda model_url: os.path.exists(model_url), url_iter))
	models = map(lambda model_url: joblib.load(model_url), url_list) if len(url_list) >= 3 else None

	scores = list(map(lambda score: float(score), sys.argv[2:]))
	result, probability = make_prediction(models, scores)

	prediction = int(result) * 2 - 1
	confidence = str(probability * 100) + "%" if probability != None else "N/A"
	print(prediction, confidence)
