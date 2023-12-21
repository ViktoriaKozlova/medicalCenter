async function getDoctor() {
  const response = await fetch("http://localhost:5002/api/Doctor", {
    method: "GET",
  });
  const result = await response.json();
  return result;
}

async function insertDoctor(
  idDoctor,
  fullName,
  birthday,
  login,
  password,
  phone,
  email,
  workSchedule
) {
  try {
    const body = JSON.stringify({
      idDoctor,
      fullName,
      birthday,
      login,
      password,
      phone,
      email,
      workSchedule,
    });
    const response = await fetch("http://localhost:5002/api/Doctor", {
      method: "POST",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Service was successfully added!");
  } catch (error) {
    console.log(error.message);
  }
}

async function newversionDoctor(
  idDoctor,
  fullName,
  birthday,
  login,
  password,
  phone,
  email,
  workSchedule
) {
  try {
    const body = JSON.stringify({
      idDoctor,
      fullName,
      birthday,
      login,
      password,
      phone,
      email,
      workSchedule,
    });
    const response = await fetch("http://localhost:5002/api/Doctor", {
      method: "PUT",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Service was successfully update!");
  } catch (error) {
    console.log(error.message);
  }
}
