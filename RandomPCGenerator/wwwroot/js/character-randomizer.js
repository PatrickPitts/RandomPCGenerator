$(document).ready(function () {

    $("#rand-chr-class").click(function () {
        $("#results").html("Clicked");
        var chrClassObject;
        $.getJSON("data/ChrClass.json", function (data) {
                       
            $("#results").html(processCharacter(data));

            
        });

        

        
    });

    $("#disappear").click(function () {
        $("#text").hide();
    });

    function randomInt(max) {
        return Math.floor(Math.random() * max);
    }

    function processCharacter(object) {
        var text = "<table>";

        var keys = Object.keys(object);
        var name = keys[randomInt(keys.length-1)+1];
        var character = object[name];
        var featuresList = [];
        var spellList = [];
        var equipmentList = [];
        
        
        

        var level = parseInt($("#chr-level").find(":selected").text());
        text += "<tr><td>Class: </td><td>" + name + "</td></tr>";
        
        function addFeature(feature) {
            featureList.push(feature);
        }

        function getListWithProperties(key, object) {
            $("#results").append("<br>Looking at").append(key);
            var jProperties = object._Prop;
            object = object[key];
            $.each(jProperties, function (propKey, value) {
                switch (propKey) {
                    case "_Choose":
                        $("#results").append("<br>Splicing " + key);

                        var list = [];
//##################################################TODO: fix loop through skill choices 
                       /* for (var i = 0; i < value; i++) {
                            var chosenSkill = value.splice(randomInt(value.length)));
                            $("#results").append("<br>Chosen " + chosenSkill);
                            //list.push(value.splice(randomInt(value.length)));
                        }*/
                        $("#results").append("<br>Done Splicing");
                        return list;
                        break;
                    default:
                        break;
                }
            });
        }



        //dummy variable, used to track lengths of lists to randomize
        var count = 0
        var str = ""
        $.each(character, function (key, value) {
            text += "<tr>"
            switch (key) {
                case "Core Features":
                    /*for (var i = 1; i <= level; i++) {
                        $.each(character[key][i.toString], function (x) {
                            if (x.indexOf("_" != -1)){

                            } else {
                                featuresList.push(x);
                            }
                        });
                    }*/
                    break;
                case "Skill Choices":
                    $("#results").append("<br>Skill Choices Referenced")
                    text += "<td>Skills:</td><td>";
                    text += getListWithProperties(key, value);
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
