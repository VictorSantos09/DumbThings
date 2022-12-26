var rickAndMortyNameOption1 = ""
var rickAndMortyNameOption2 = ""
var rickAndMortyNameOption3 = ""

var correctName = ""

var resultArray = []

const divSpace1 = document.getElementById("spaceNameBox-1")
const divSpace2 = document.getElementById("spaceNameBox-2")
const divSpace3 = document.getElementById("spaceNameBox-3")

const rickAndMortyRadio1 = document.getElementById("rickAndMortyOption1")
const rickAndMortyRadio2 = document.getElementById("rickAndMortyOption2")
const rickAndMortyRadio3 = document.getElementById("rickAndMortyOption3")

const GetCaracter = async function (idImg) {

    CleanDivsAndUncheckRadio()

    const req = await fetch("https://localhost:7205/DumbThings/GetRickAndMorty",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify()
        })

    const result = await req.json();

    correctName = result.correctChoice.name

    document.getElementById(idImg).setAttribute("src", result.correctChoice.image)
    document.getElementById(idImg).setAttribute("alt", "rick and morty random caracter")

    resultArray = [result.correctChoice.name, result.wrongChoice1.name, result.wrongChoice2.name]

    var randomIndex = MakeRandomIndex()

    var index0 = randomIndex[0]
    var index1 = randomIndex[1]
    var index2 = randomIndex[2]

    rickAndMortyNameOption1 = document.getElementById("rickAndMortyOption-1").innerHTML = resultArray[index0]
    rickAndMortyNameOption2 = document.getElementById("rickAndMortyOption-2").innerHTML = resultArray[index1]
    rickAndMortyNameOption3 = document.getElementById("rickAndMortyOption-3").innerHTML = resultArray[index2]
}

GetCaracter("rickAndMortyCaracter")

function MakeRandomIndex() {

    let finalArray = []

    while (true) {
        let index = Math.floor(Math.random() * 3)

        if (finalArray.length == 3)
            break

        if (finalArray.includes(index) == false)
            finalArray.push(index)
    }

    return finalArray
}

function CheckNameAndRecall(nameChoice, correctName, divId) {
    if (nameChoice == correctName)
        document.getElementById(divId).style.backgroundColor = 'green';

    else
        document.getElementById(divId).style.backgroundColor = 'red'

    setTimeout(() => {
        GetCaracter("rickAndMortyCaracter")
    }, 1000);
}

function CleanDivsAndUncheckRadio() {
    divSpace1.style.backgroundColor = 'white'
    divSpace2.style.backgroundColor = 'white'
    divSpace3.style.backgroundColor = 'white'
    rickAndMortyRadio1.checked = false
    rickAndMortyRadio2.checked = false
    rickAndMortyRadio3.checked = false
}

rickAndMortyRadio1.addEventListener("click", () => CheckNameAndRecall(rickAndMortyNameOption1, correctName, "spaceNameBox-1"))
rickAndMortyRadio2.addEventListener("click", () => CheckNameAndRecall(rickAndMortyNameOption2, correctName, "spaceNameBox-2"))
rickAndMortyRadio3.addEventListener("click", () => CheckNameAndRecall(rickAndMortyNameOption3, correctName, "spaceNameBox-3"))
