import { RoleEnum } from "../enum/Role";
import { useContext } from "react";
import { UserContext } from '../functions/UserContext';
import { useGetInstitutionById } from "../greatergradesapi/Institutions";
import { FaUser, FaUserCircle, FaBuilding, FaIdBadge } from 'react-icons/fa';

const ProfileContent = () => {
    
    const { currentUser } = useContext(UserContext);
    const { institution, loading } = useGetInstitutionById(currentUser?.institutionId);

    return (
        <div className="content-card">
            <h2>Profile Information</h2>
            <div className="profile-field">
                <FaUser /> <span className="field-label">First Name:</span> {currentUser?.firstName}
            </div>
            <div className="profile-field">
                <FaUser /> <span className="field-label">Last Name:</span> {currentUser?.lastName}
            </div>
            <div className="profile-field">
                <FaUserCircle /> <span className="field-label">Username:</span> {currentUser?.username}
            </div>
            <div className="profile-field">
                <FaIdBadge /> <span className="field-label">Role:</span> {RoleEnum[currentUser?.role]}
            </div>
            <div className="profile-field">
                <FaBuilding /> <span className="field-label">Institution:</span> {loading ? 'Loading...' : institution?.name}
            </div>
        </div>
    );
};

export default ProfileContent;
