import { useState, useContext } from "react";
import { addInstitution } from "../greatergradesapi/Institutions";
import { UserContext } from "../functions/UserContext";

const AddInstitutionPopup = ({ onClose }) => {
    const [error, setError] = useState('');
    const [institutionName, setInstitutionName] = useState('');
    const { authToken } = useContext(UserContext);

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!institutionName) {
            setError('Name is required.');
            return;
        }

        await addInstitution(institutionName, authToken);
        onClose();
    }

    return (
        <div className="popup-overlay">
            <div className="popup">
                <h2>Add New Institution</h2>
                <form onSubmit={handleSubmit}>
                    <div>
                        <label htmlFor="institutionName">Institution Name:</label>
                        <input
                            type="text"
                            id="institutionName"
                            value={institutionName}
                            onChange={(e) => setInstitutionName(e.target.value)}
                            required
                        />
                    </div>
                    {error && <p className="error">{error}</p>}
                    <button type="submit">Submit</button>
                    <button type="button" onClick={onClose}>Cancel</button>
                </form>
            </div>
        </div>
    )
}

export default AddInstitutionPopup;