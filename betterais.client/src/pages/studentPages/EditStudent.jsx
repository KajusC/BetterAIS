import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom"; // Updated import
import { getAllPrograms } from "../../scripts/programsAPI";
import { getStudentByVidko, updateStudent } from "../../scripts/studentAPI";
import ToastNotification from '../../components/ToastNotification';

export default function EditStudent() {
  const { vidko } = useParams();
  const navigate = useNavigate(); // Updated hook
  const [student, setStudent] = useState({
    vardas: "",
    pavarde: "",
    gimimoData: "",
    telefonoNr: "",
    elPastas: "",
    roleId: 3,
    slaptazodis: "",
    vidko: "",
    studijuPradzia: "",
    statusas: "",
    finansavimas: "",
    fkProgramosKodas: "",
    slaptazodis: "abc",
  });
  const [programs, setPrograms] = useState([]);
  const [showToast, setShowToast] = useState(false);
  const [toastMessage, setToastMessage] = useState('');
  const [toastType, setToastType] = useState('success');

  // Fetch student data
  useEffect(() => {
    getStudentByVidko(vidko)
      .then((data) => {
        // Patikrink ir formatuok datą
        const formattedDate = data.gimimoData ? data.gimimoData.split('T')[0] : '';
        setStudent((prevStudent) => ({
          ...prevStudent,
          ...data,
          gimimoData: formattedDate,
        }));
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  }, [vidko]);
  

  // Fetch programs data
  useEffect(() => {
    getAllPrograms().then((response) => {
      setPrograms(response.map((program) => ({ key: program.programosKodas })));
    });
  }, []);

  // Handle input changes
  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setStudent((prevStudent) => ({
      ...prevStudent,
      [id]: value,
    }));
  };

  // Handle form submission
  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await updateStudent(vidko, student);
      if (response.status === 200) {
        setToastMessage('Studento informacija sėkmingai atnaujinta');
        setToastType('success');
        setShowToast(true);
        setTimeout(() => {
          navigate(`/StudentProfile/${vidko}`); // Updated navigation
        }, 2000);
      } else {
        setToastMessage('Klaida atnaujinant studento informaciją');
        setToastType('danger');
        setShowToast(true);
      }
    } catch (error) {
      console.error('Error updating student:', error);
      setToastMessage('Klaida atnaujinant studento informaciją');
      setToastType('danger');
      setShowToast(true);
    }
  };

  return (
		<div className="p-6 bg-gray-50 min-h-screen dark:bg-gray-900 dark:text-white">
			<ToastNotification
				show={showToast}
				message={toastMessage}
				type={toastType}
				onClose={() => setShowToast(false)}
			/>
			<h1 className="text-3xl font-bold mb-4">
				Redaguoti studentą (Vidko: {student.vidko})
			</h1>
			<form onSubmit={handleSubmit}>
				<div className="dark:bg-gray-800 shadow-md rounded-lg p-6 mb-6">
					<h2 className="text-2xl font-semibold mb-2">Asmeninė informacija</h2>
					<div className="flex flex-col md:flex-row">
						<div className="flex flex-col w-full md:w-1/2 md:mr-4">
							<label className="text-lg font-semibold mb-2" htmlFor="vardas">
								Vardas
							</label>
							<input
								className="p-2 border rounded"
								type="text"
								id="vardas"
								value={student.vardas || ""}
								onChange={handleInputChange}
								required
							/>
						</div>
						<div className="flex flex-col w-full md:w-1/2 md:ml-4">
							<label className="text-lg font-semibold mb-2" htmlFor="pavarde">
								Pavardė
							</label>
							<input
								className="p-2 border rounded"
								type="text"
								id="pavarde"
								value={student.pavarde || ""}
								onChange={handleInputChange}
								required
							/>
						</div>
						<div className="flex flex-col w-full md:w-1/2 md:ml-4">
							<label
								className="text-lg font-semibold mb-2"
								htmlFor="gimimoData"
							>
								Gimimo data
							</label>
							<input
								className="p-2 border rounded"
								type="date" // Ensure the type is 'date' for better UX
								id="gimimoData" // Must match the state key
								value={student.gimimoData || ""}
								onChange={handleInputChange}
								required
							/>
						</div>
					</div>
					<h2 className="text-2xl font-semibold mb-2 pt-4">
						Kontaktinė informacija
					</h2>
					<div className="flex flex-col md:flex-row">
						<div className="flex flex-col w-full md:w-1/2 md:mr-4">
							<label className="text-lg font-semibold mb-2" htmlFor="elPastas">
								El. paštas
							</label>
							<input
								className="p-2 border rounded"
								type="email" // Changed to email
								id="elPastas"
								value={student.elPastas || ""}
								onChange={handleInputChange}
								required
							/>
						</div>
						<div className="flex flex-col w-full md:w-1/2 md:ml-4">
							<label
								className="text-lg font-semibold mb-2"
								htmlFor="telefonoNr"
							>
								Telefonas
							</label>
							<input
								className="p-2 border rounded"
								type="tel" // Changed to tel
								id="telefonoNr"
								value={student.telefonoNr || ""}
								onChange={handleInputChange}
								required
							/>
						</div>
					</div>
					<h2 className="text-2xl font-semibold mb-2 pt-4">
						Studijų informacija
					</h2>
					<div className="flex flex-col md:flex-row">
						<div className="flex flex-col w-full md:w-1/2 md:ml-4">
							<label
								className="text-lg font-semibold mb-2"
								htmlFor="fkProgramosKodas"
							>
								Studijų programa
							</label>
							<select
								className="p-2 border rounded"
								id="fkProgramosKodas"
								value={student.fkProgramosKodas || ""}
								onChange={handleInputChange}
								required
							>
								<option value="" disabled>
									Select a program
								</option>
								{programs.map((program) => (
									<option key={program.key} value={program.key}>
										{program.key}
									</option>
								))}
							</select>
						</div>
						<div className="flex flex-col w-full md:w-1/2 md:ml-4">
							<label
								className="text-lg font-semibold mb-2 pt-4"
								htmlFor="statusas"
							>
								Statusas
							</label>
							<select
								className="p-2 border rounded"
								id="statusas"
								value={student.statusas || ""}
								onChange={handleInputChange}
								required
							>
								<option value="" disabled>
									Select status
								</option>
								<option value="1">Aktyvus</option>
								<option value="2">Sustabdytas</option>
								<option value="3">Terminuotas</option>
								<option value="4">Baigtas</option>
							</select>
						</div>
						<div className="flex flex-col w-full md:w-1/2 md:ml-4">
							<label
								className="text-lg font-semibold mb-2 pt-4"
								htmlFor="finansavimas"
							>
								Finansavimas
							</label>
							<select
								className="p-2 border rounded"
								id="finansavimas"
								value={student.finansavimas || ""}
								onChange={handleInputChange}
								required
							>
								<option value="" disabled>
									Select financing
								</option>
								<option value="1">Valstybinis</option>
								<option value="2">Nevalstybinis</option>
							</select>
						</div>
					</div>
				</div>
				<button
					className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
					type="submit"
				>
					Išsaugoti
				</button>
			</form>
		</div>
	);
}