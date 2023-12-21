async function displayService() {
  let values = await getService();

  let valuesTable = document.getElementById("getService");

  for (let value of values) {
    const { idService, nameService, price } = value;

    const row = document.createElement("tr");
    const idServiceEl = document.createElement("td");
    const nameServiceEl = document.createElement("td");
    const priceEl = document.createElement("td");

    idServiceEl.classList.add("element");
    nameServiceEl.classList.add("element");
    priceEl.classList.add("element");

    idServiceEl.innerText = idService;
    nameServiceEl.innerText = nameService;
    priceEl.innerText = price;

    row.append(idServiceEl, nameServiceEl, priceEl);

    valuesTable.append(row);
  }
}

async function addService(event) {
  event.preventDefault();
  const form = event.target;
  const { idService, nameService, price } = form.elements;
  await insertService(idService.value, nameService.value, price.value);

  location.reload();
}

async function updateService(event) {
  event.preventDefault();
  const form = event.target;
  const { idService, nameService, price } = form.elements;
  await newversionService(idService.value, nameService.value, price.value);

  location.reload();
}

async function removeService(event) {
  event.preventDefault();
  const form = event.target;
  const { idService } = form.elements;
  await deleteService(idService.value);
  location.reload();
}
displayService();
document
  .querySelector("#add-service-form")
  .addEventListener("submit", addService);
document
  .getElementById("delete-service-form")
  .addEventListener("submit", removeService);
document
  .getElementById("update-service-form")
  .addEventListener("submit", updateService);
