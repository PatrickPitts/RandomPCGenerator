


function getCharacterJSON() {
    let xhr = new XMLHttpRequest();
    xhr.open('Get', '~/data/ChrClass.json', true);
    xhr.responseType = 'text';
    document.getElementById("text").innerHTML = "Button clicked"
    xhr.onload = function () {
        if (this.status === 200) {
            document.getElementById("text").innerHTML = JSON.parse(xhr.responseText);
        }
    }

}
    


