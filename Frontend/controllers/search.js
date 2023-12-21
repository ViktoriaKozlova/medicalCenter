async function displayView(filter) {
  let values = await getConsSearch(filter);
  //  console.log("rooms", rooms);

  let valuesTable = document.getElementById("getCons");
  const rows = valuesTable.querySelectorAll("tr");

  // Iterate over the rows and remove them
  rows.forEach(function (row, index) {
    if (index === 0) {
      return;
    }
    row.remove();
  });

  for (let value of values) {
    const {
      idConslusion,
      information,
      fullNameDoctor,
      fullNameUser,
      dateReception,
      timeReception,
    } = value;

    const row = document.createElement("tr");
    const idConslusionEl = document.createElement("td");
    const informationEl = document.createElement("td");
    const fullNameDoctorEl = document.createElement("td");
    const fullNameUserEl = document.createElement("td");
    const dateReceptionEl = document.createElement("td");
    const timeReceptionEl = document.createElement("td");

    idConslusionEl.classList.add("element");
    informationEl.classList.add("element");
    fullNameDoctorEl.classList.add("element");
    fullNameUserEl.classList.add("element");
    dateReceptionEl.classList.add("element");
    timeReceptionEl.classList.add("element");

    idConslusionEl.innerText = idConslusion;
    informationEl.innerText = information;
    fullNameDoctorEl.innerText = fullNameDoctor;
    fullNameUserEl.innerText = fullNameUser;
    dateReceptionEl.innerText = dateReception;
    timeReceptionEl.innerText = timeReception;

    row.append(
      idConslusionEl,
      informationEl,
      fullNameDoctorEl,
      fullNameUserEl,
      dateReceptionEl,
      timeReceptionEl
    );

    valuesTable.append(row);
    console.log(row);
  }
}
displayView(filter);
