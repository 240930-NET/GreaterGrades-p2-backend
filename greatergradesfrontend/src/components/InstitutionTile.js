import forestImage from "../images/forest.jfif";
import { deleteInstitution, useGetAllInstitutions } from "../greatergradesapi/Institutions";
import { useContext, useState } from "react";
import { UserContext } from "../functions/UserContext";
import UpdateInstitutionPopup from "./UpdateInstitutionPopup";

const InstitutionTile = () => {
    const instituitons = useGetAllInstitutions();
    const { authToken } = useContext(UserContext);
    const [popupInstitutionId, setPopupInstitutionId] = useState(null);

    const handleRemoveInstitutionClick = (id) => {
        deleteInstitution(id, authToken)
    }

    const handleUpdateInstitutionClick = (id) => {
        setPopupInstitutionId(popupInstitutionId === id ? null : id);
    }

    return (
        <div className="tiles-container">
            {instituitons.map((institution) => (
                <div key={institution.institutionId} className="dashboard-tile">
                    <h3 className="tile-title">{institution.name}</h3>
                    <img src={forestImage} alt="Course placeholder" className="tile-image" />
                    <div className="tile-footer">
                        <button onClick={() => handleRemoveInstitutionClick(institution.institutionId)}>
                            Remove
                        </button>
                        <button onClick={() => handleUpdateInstitutionClick(institution.institutionId)}>
                            Update
                        </button>
                    </div>
                    {popupInstitutionId === institution.institutionId && (
                        <UpdateInstitutionPopup onClose={() => setPopupInstitutionId(null)} institutionId={institution.institutionId} />
                    )}
                </div>
            ))}
        </div>
    )
}

export default InstitutionTile;