var rickAndMortyNameOption1 = ""
var rickAndMortyNameOption2 = ""
var rickAndMortyNameOption3 = ""
var correct = ""
var resultArray = []
var amountReqRickMorty = 0
const timeoutRequest = 600
const maxCaracters = 826
const divSpace1 = document.getElementById("spaceNameBox-1")
const divSpace2 = document.getElementById("spaceNameBox-2")
const divSpace3 = document.getElementById("spaceNameBox-3")

const GetCaracter = async function (idImg) {
    let characters = []
    PopulateArray(characters)

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
    rickAndMortyNameOption1 = document.getElementById("rickAndMortyOption-1").innerHTML = 'A) ' + resultArray[0]
    rickAndMortyNameOption2 = document.getElementById("rickAndMortyOption-2").innerHTML = 'B) ' + resultArray[1]
    rickAndMortyNameOption3 = document.getElementById("rickAndMortyOption-3").innerHTML = 'C) ' + resultArray[2]
}

function MakeRandomIndex(max) {
    return Math.floor(Math.random() * max)
}

function CheckNameAndRecall(nameChoice, correctName, divId) {
    amountReqRickMorty++
    if (nameChoice == correctName) {
        document.getElementById(divId).style.backgroundColor = 'green';
        setTimeout(() => {
            CleanDivs()
        }, timeoutRequest);
    }

    else {
        document.getElementById(divId).style.backgroundColor = 'red'
        setTimeout(() => {
            CleanDivs()
        }, timeoutRequest);
    }

    if (amountReqRickMorty == 1) {
        setTimeout(() => {
            GetCaracter("rickAndMortyCaracter")
            amountReqRickMorty = 0;
        }, timeoutRequest);
    }
}

function CleanDivs() {
    divSpace1.style.backgroundColor = 'white'
    divSpace2.style.backgroundColor = 'white'
    divSpace3.style.backgroundColor = 'white'
    divSpace1.classList.add('btn')
    divSpace2.classList.add('btn')
    divSpace3.classList.add('btn')

    divSpace1.classList.add('btn-light')
    divSpace2.classList.add('btn-light')
    divSpace3.classList.add('btn-light')
}

function PopulateArray(characters) {
    let maxNumbers = 3;
    do {
        let value = MakeRandomIndex(maxCaracters)
        if (characters.includes(value) == false) {
            characters.push(value)
            maxNumbers--;
        }
    } while (maxNumbers > 0);
}

divSpace1.addEventListener("click", () => CheckNameAndRecall(rickAndMortyNameOption1, correct.name, "spaceNameBox-1"))
divSpace2.addEventListener("click", () => CheckNameAndRecall(rickAndMortyNameOption2, correct.name, "spaceNameBox-2"))
divSpace3.addEventListener("click", () => CheckNameAndRecall(rickAndMortyNameOption3, correct.name, "spaceNameBox-3"))
GetCaracter("rickAndMortyCaracter")