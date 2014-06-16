// Blake Triana
// dbp-nre.js
// Summary: Creates debug print statements to find a null reference exception from an expression that
// that has multiple accesses

function CreateOutputString(conditionTokens) {
	var outputString = "";
	outputString += "// #debug - debug null reference exception" + "\n";
	outputString += "string dbgMsg = \"\";" + "\n";

	// Iteratively add null check statements from broken down expressions
	for (var i = 0; i < conditionTokens.length; ++i) {
		var tabsToAdd = i;
		var tabs = "";
		for (var j = 0; j < tabsToAdd; ++j) {
			tabs += "	";
		}

		// Initial null check expression - recursively add all previous objects
		var conditionToAdd = "";
		for (var j = i; j > -1; --j) {
			conditionToAdd = conditionTokens[j] + conditionToAdd;
			if (j != 0) {
				conditionToAdd = "." + conditionToAdd;
			}
		}

		outputString += tabs + "dbgMsg += \"  (" + conditionToAdd + " != null) = \"" 
			+ " + (" + conditionToAdd + " != null);" + "\n";

		// If there's more conditionTokens to add, create an if statement for the next null check expression
		if (i < (conditionTokens.length - 1)) {
			outputString += tabs + "if (" + conditionToAdd + " != null) {" + "\n";
		}
	}

	// Add closing braces
	for (var i = 0; i < conditionTokens.length - 1; ++i) {
		var tabsToAdd = conditionTokens.length - 2 - i;
		var tabs = "";
		for (var j = 0; j < tabsToAdd; ++j) {
			tabs += "	";
		}
		outputString += tabs + "}" + "\n";
	}

	outputString += "GameLog.info(dbgMsg);" + "\n";	
	return outputString;
}

function GetObjectsInExpression(expressionTokens) {
	var objects = [];

	// Last statement is not evaluated since that error would be in a different place in code
	for (var i = 0; i < expressionTokens.length; ++i) {
		if (i != (expressionTokens.length - 1)) {
			objects.push(expressionTokens[i]);
		}
	}

	return objects;
}

function GetConditionsStrings() {
	var conditionsStrings = [];
	for (var i = 0; i < objectsInExpression.length; ++i) {
		var conditionString = "";
		for (var j = i; j > -1; --j) {
			// Don't add an accessor for first iteration
			if (j != i) {
				conditionString = "." + conditionString;
			}

			conditionString = objectsInExpression[j] + conditionString;
		}
		conditionsStrings.push(conditionString);
	}
	return conditionsStrings;
}

if (process.argv.length > 2) {
	console.log(process.argv[2]);
	var expression = process.argv[2];
	var expressionParts = expression.split(".");
	var objectsInExpression = GetObjectsInExpression(expressionParts);
	var conditionStatements = GetConditionsStrings(objectsInExpression);
	console.log(CreateOutputString(objectsInExpression));
}
