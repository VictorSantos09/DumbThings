const buttonReq = document.getElementById("inputButton")
const nameUser = document.getElementById("inputName")

const GuessUser = async function () {

    const req = await fetch("https://localhost:7205/DumbThings/GetGenderAndAge",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify({ name: nameUser.value })
        })

    const result = await req.json();

    const name = " Name: "
    const age = "Age: "
    const gender = "Gender: "

    document.getElementById("resultName").innerHTML = name.concat(result.name)
    document.getElementById("resultAge").innerHTML = age.concat(result.age)
    document.getElementById("resultGender").innerHTML = gender.concat(result.gender)

    setTimeout(function () { alert("Congrats " + result.name + " You are a " + result.gender + " Of " + result.age + " Years Old"); }, 50);
}
buttonReq.addEventListener("click", () => GuessUser())