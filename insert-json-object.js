// This file inserts a Json key value pair into an existing JSON hierarchy

var FileSystem = require("fs");
var Directory = __dirname;
var parsedFiles = {};

console.log("Running script main.js...");

FileSystem.readdir(Directory, function (err, dirFiles) {
	if (err) {
		return;
	}
	if (dirFiles.length == 0) {
		return;
	}

	dirFiles.forEach(function (file) {
		var fileNameParts = file.split(".");
		if (fileNameParts.length < 3 || fileNameParts[1] != "json" || fileNameParts[2] != "txt" ) {
			console.log("Ignoring file " + file + "...");
			return; // skip non-json.txt files
		}

		var filePath = Directory + '/' + file;
		var data = FileSystem.readFile(filePath, 'utf8', function (err, data) {
			// Check if each file has "RelevantResearch" - if not, generate it and insert it
			var jsonData = JSON.parse(data);

			if (jsonData != null) {
				var relevantResearchName = "";

				// Get the name of the RelevantResearch to insert
				if (jsonData.hasOwnProperty("name")) {
					var jsonName = jsonData["name"];
					var jsonNameParts = jsonName.split('_');

					for (var i = 0; i < jsonNameParts.length; ++i) {
						if (i != 1) {
							relevantResearchName += jsonNameParts[i];
						} else { // we replace "resource" with "research"
							relevantResearchName += "research";
						}

						if (i != (jsonNameParts.length - 1)) { // do not add underscores at the end
							relevantResearchName += '_';
						}
					}
				}

				// Insert the key and value we want				
				if (jsonData.hasOwnProperty("components")
					&& jsonData["components"].hasOwnProperty("Resource")
					&& !jsonData["components"]["Resource"].hasOwnProperty("RelevantResearch")) {
					jsonData["components"]["Resource"]["RelevantResearch"] = relevantResearchName;
				}

				// Write the file
				FileSystem.writeFile(filePath, JSON.stringify(jsonData, undefined, "	"), 'utf8', function (err) {
					if (err) {
						throw err;
					}
					console.log("Writing " + file + "...");
				});
			}
		});
	});
});
