import { useState, useContext } from "react";
import { UserContext } from "../functions/UserContext";
import AddInstitutionPopup from "./AddInstitutionPopup";
import InstitutionTile from "./InstitutionTile";

const InstitutionContent = () => {
    const { currentUser } = useContext(UserContext);
    const[isAddPopupOpen, setAddPopupOpen] = useState(false);

    const handleAddInstitutionClick = () => {
        setAddPopupOpen(true);
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
            {isAddPopupOpen && (
                <AddInstitutionPopup onClose={() => setAddPopupOpen(false)} institutionId={currentUser?.institutionId} />
            )}
        </div>
    )
}

export default InstitutionContent;