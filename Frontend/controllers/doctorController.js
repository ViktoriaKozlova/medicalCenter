async function displayDoctor() {
  let values = await getDoctor();

  let valuesTable = document.getElementById("getDoctor");

  for (let value of values) {
    const {
      idDoctor,
      fullName,
      birthday,
      login,
      password,
      phone,
      email,
      workSchedule,
    } = value;

    const row = document.createElement("tr");

    const idDoctorEl = document.createElement("td");
    const fullNameEl = document.createElement("td");
    const birthdayEl = document.createElement("td");
    const loginEl = document.createElement("td");
    const passwordEl = document.createElement("td");
    const phoneEl = document.createElement("td");
    const emailEl = document.createElement("td");
    const workScheduleEl = document.createElement("td");
    idDoctorEl.classList.add("element");
    fullNameEl.classList.add("element");
    birthdayEl.classList.add("element");
    loginEl.classList.add("element");
    passwordEl.classList.add("element");
    phoneEl.classList.add("element");
    emailEl.classList.add("element");
    workScheduleEl.classList.add("element");

    idDoctorEl.innerText = idDoctor;
    fullNameEl.innerText = fullName;
    birthdayEl.innerText = birthday;
    loginEl.innerText = login;
    passwordEl.innerText = password;
    phoneEl.innerText = phone;
    emailEl.innerText = email;
    workScheduleEl.innerText = workSchedule;

    row.append(
      idDoctorEl,
      fullNameEl,
      birthdayEl,
      loginEl,
      passwordEl,
      phoneEl,
      emailEl,
      workScheduleEl
    );

    valuesTable.append(row);
  }
}

async function addDoctor(event) {
  event.preventDefault();
  const form = event.target;
  const {
    idDoctor,
    fullName,
    birthday,
    login,
    password,
    phone,
    email,
    workSchedule,
  } = form.elements;
  await insertDoctor(
    idDoctor.value,
    fullName.value,
    birthday.value,
    login.value,
    password.value,
    phone.value,
    email.value,
    workSchedule.value
  );

  location.reload();
}

async function updateDoctor(event) {
  event.preventDefault();
  const form = event.target;
  const {
    idDoctor,
    fullName,
    birthday,
    login,
    password,
    phone,
    email,
    workSchedule,
  } = form.elements;
  await newversionDoctor(
    idDoctor.value,
    fullName.value,
    birthday.value,
    login.value,
    password.value,
    phone.value,
    email.value,
    workSchedule.value
  );

  location.reload();
}
displayDoctor();

document
  .querySelector("#add-doctor-form")
  .addEventListener("submit", addDoctor);

document
  .getElementById("update-doctor-form")
  .addEventListener("submit", updateDoctor);
