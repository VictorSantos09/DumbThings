var rickAndMortyNameOption1 = ""
var rickAndMortyNameOption2 = ""
var rickAndMortyNameOption3 = ""
var correct = ""
var resultArray = []
const maxCaracters = 826
const divSpace1 = document.getElementById("spaceNameBox-1")
const divSpace2 = document.getElementById("spaceNameBox-2")
const divSpace3 = document.getElementById("spaceNameBox-3")
const rickAndMortyRadio1 = document.getElementById("rickAndMortyOption1")
const rickAndMortyRadio2 = document.getElementById("rickAndMortyOption2")
const rickAndMortyRadio3 = document.getElementById("rickAndMortyOption3")

const GetCaracter = async function (idImg) {
    CleanDivsAndUncheckRadio()
    let characters = []
    let value = 0

    value = MakeRandomIndex(maxCaracters, characters)
    characters.push(value)
    console.log(characters.l);

    const req = await fetch("https://rickandmortyapi.com/api/character/" + characters[0] + "," + characters[1] + "," + characters[2],
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "GET",
            body: JSON.stringify()
        })

    const result = await req.json();
    correct = result[MakeRandomIndex(3)]

    document.getElementById(idImg).setAttribute("src", correct.image)
    document.getElementById(idImg).setAttribute("alt", "image of " + correct.name)

    resultArray = [result[0].name, result[1].name, result[2].name]

    rickAndMortyNameOption1 = document.getElementById("rickAndMortyOption-1").innerHTML = resultArray[MakeRandomIndex(3)]
    rickAndMortyNameOption2 = document.getElementById("rickAndMortyOption-2").innerHTML = resultArray[MakeRandomIndex(3)]
    rickAndMortyNameOption3 = document.getElementById("rickAndMortyOption-3").innerHTML = resultArray[MakeRandomIndex(3)]
}

function MakeRandomIndex(max, array = null) {

    if (array == null)
        return Math.floor(Math.random() * max)

    else
        do {
            var value = Math.floor(Math.random() * max)
        } while (array.includes(value) == false);
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
GetCaracter("rickAndMortyCaracter")