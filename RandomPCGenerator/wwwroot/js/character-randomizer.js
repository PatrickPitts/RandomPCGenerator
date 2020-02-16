$(document).ready(function () {

    $("#rand-chr-class").click(function () {
        $("#results").html("Clicked");
        var chrClassObject;
        $.getJSON("data/ChrClass.json", function (data) {                      
            $("#random-chr-display").html(processCharacter(data));
        });
    });

    function selectOneAtRandom(arr) {
         return arr[randomInt(arr.length)];
    }

    function randomInt(max) {
        return Math.floor(Math.random() * max);
    }

    function dive(arr, properties, depth, ret) {

        
        if (typeof arr === 'string' || arr instanceof String) {
            $("#results").append("<br> arr is String: " + arr + "  depth: " + depth);

            ret = ret.concat(arr);
            $("#results").append("<br> ret: " + JSON.stringify(ret) + "  depth: " + depth);

            return ret;
        }
        $("#results").append("<br> arr: " + JSON.stringify(arr) + "  depth: " + depth);

        if (properties[depth] === "s") {
            var val = selectOneAtRandom(arr);
            if (typeof val === 'string' || val instanceof String) {
                ret = ret.concat(val);
                $("#results").append("<br>s ret: " + JSON.stringify(ret) + "  depth: " + depth);

            } else {
                ret = dive(val, properties, depth + 1, ret);
                $("#results").append("<br>s ret: " + JSON.stringify(ret) + "  depth: " + depth);

            }
            
            
        } else if (properties[depth] === "a") {
            $(arr).each(function (index, elem) {

                if (typeof elem === 'string' || elem instanceof String) {
                    ret = ret.concat(elem);
                    $("#results").append("<br>a ret: " + JSON.stringify(ret) + "  depth: " + depth);

                } else  {
                    ret = dive(elem, properties, depth + 1, ret);
                    $("#results").append("<br>a ret: " + JSON.stringify(ret) + "  depth: " + depth);

                }
                
            });      
        }
        return ret;
    }

    function getListWithProperties(key, object) {
        $("#results").append("<br>Looking at ").append(key);
        var jProperties = object._Prop;
        object = object[key];


        var list = [];
        $.each(jProperties, function (propKey, value) {
            $("#results").append("<br>propKey: " + propKey + " value: " + JSON.stringify(value));
            
            switch (propKey) {
                case "_Choose":
                    for (var i = 0; i < parseInt(value); i++) {
                        var chosenSkill = object.splice(randomInt(value.length), 1);

                        list.push(chosenSkill[0]);
                    }
                    break;
                case "_Dive":
                    list = []
                    list = dive(object, value, 0, list);
                        $("#results").append("<br> list: " + list);

                    
                    break;
                default:
                    break;
            }
            
        });


        return list;
    }

    function processCharacter(object) {
        var text = "<table>";

        var keys = Object.keys(object);
        var name = keys[randomInt(keys.length - 1) + 1];
        $("#results").append("<br>Class: " + name);
        var character = object[name];
        var featuresList = [];
        var spellList = [];
        var equipmentList = [];
        var proficiencyList = [];
        
        var test = [1, 2, 3];
        var test2 = [4, 5, 6];
        
        $("#results").append("<br>Test: " + JSON.stringify(test.concat(4)));

        

        var level = parseInt($("#chr-level").find(":selected").text());
        text += "<tr><td>Class: </td><td>" + name + "</td></tr>";
        
        function addFeature(feature) {
            featureList.push(feature);
        }


        //dummy variable, used to track lengths of lists to randomize
        var count = 0
        var str = ""
        $.each(character, function (key, value) {
            text += "<tr>"
            switch (key) {
                case "Proficiencies":
                    text += "<td>Other Proficiencies</td><td>";
                    $(value).each(function (index, value) {
                        
                    });


                    break;
                case "Core Features":
                    for (var i = 1; i <= level; i++) {

                    }
                    break;
                case "Skill Choices":
                    text += "<td>Skills:</td><td>";
                    var chosenSkills = getListWithProperties(key, value);
                    $(chosenSkills).each(function (index, value) {
                        text += value + "<br>";
                    });
                    text += "</td>";
                    break;
                case "Equipment":
                    text += "<td>Equipment:</td><td>";
                    var equipment = getListWithProperties(key, value);
                    $(equipment).each(function (index, value) {
                        text += value + "<br>";
                    });
                    text += "</td>";
                    break;
                default:
                    break;
            }
            text += "</tr>"
        });

        text += "</table>";
        return text;
  
    }

});
