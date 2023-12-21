async function displayReception() {
  let values = await getReception();

  let valuesTable = document.getElementById("getReception");

  for (let value of values) {
    const { idReception, date, time, visit, user, serviceId, doctorId } = value;

    const row = document.createElement("tr");

    const idReceptionEl = document.createElement("td");
    const dateEl = document.createElement("td");
    const timeEl = document.createElement("td");
    const visitEl = document.createElement("td");
    const userEl = document.createElement("td");
    const serviceIdEl = document.createElement("td");
    const doctorIdEl = document.createElement("td");

    idReceptionEl.classList.add("element");
    dateEl.classList.add("element");
    timeEl.classList.add("element");
    visitEl.classList.add("element");
    userEl.classList.add("element");
    serviceIdEl.classList.add("element");
    doctorIdEl.classList.add("element");

    idReceptionEl.innerText = idReception;
    dateEl.innerText = date;
    timeEl.innerText = time;
    visitEl.innerText = visit;
    userEl.innerText = user;
    serviceIdEl.innerText = serviceId;
    doctorIdEl.innerText = doctorId;

    row.append(
      idReceptionEl,
      dateEl,
      timeEl,
      visitEl,
      userEl,
      serviceIdEl,
      doctorIdEl
    );

    valuesTable.append(row);
  }
}

async function addDoctor(event) {
  event.preventDefault();
  const form = event.target;
  const { idReception, date, time, visit, user, serviceId, doctorId } =
    form.elements;
  await insertDoctor(
    idReception.value,
    date.value,
    time.value,
    visit.value,
    user.value,
    serviceId.value,
    doctorId.value
  );

  location.reload();
}

async function removeReception(event) {
  event.preventDefault();
  const form = event.target;
  const { idReception } = form.elements;
  await deleteReception(idReception.value);
  location.reload();
}
displayReception();
document
  .querySelector("#add-reception-form")
  .addEventListener("submit", addReception);
document
  .getElementById("delete-reception-form")
  .addEventListener("submit", removeReception);
