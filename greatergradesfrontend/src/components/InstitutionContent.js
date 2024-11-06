import { useState, useContext } from "react";
import { UserContext } from "../functions/UserContext";
import AddInstitutionPopup from "./AddInstitutionPopup";
import InstitutionTile from "./InstitutionTile";

const InstitutionContent = () => {
    const { currentUser } = useContext(UserContext);
    const[isPopupOpen, setPopupOpen] = useState(false);

    const handleAddInstitutionClick = () => {
        setPopupOpen(true);
    };

    return (
        <div className="dashboard-content">
            <div className="dashboard-header">
                <h3>Institutions</h3>
                <button className="add-class-button" onClick={handleAddInstitutionClick}>
                    Add New Institution
                </button>
            </div>
            <div className="dashboard-tiles">
                <InstitutionTile />
            </div>
            {isPopupOpen && (
                <AddInstitutionPopup onClose={() => setPopupOpen(false)} institutionId={currentUser?.institutionId} />
            )}
        </div>
    )
}

export default InstitutionContent;