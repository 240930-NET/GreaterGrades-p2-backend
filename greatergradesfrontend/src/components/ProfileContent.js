import { RoleEnum } from "../enum/Role";
import { getStorageItem } from "../functions/functions";
import { useGetInstitutionById } from "../greatergradesapi/Institutions";
const ProfileContent = () => {
    
    const currentUser = getStorageItem('currentUser')

    const institution = useGetInstitutionById(currentUser?.institutionId)

    return (
        <div className="student-content">
            <p>First Name: {currentUser?.firstName}</p>
            <p>Last Name: {currentUser?.lastName}</p>
            <p>Username: {currentUser?.username}</p>
            <p>Role: {RoleEnum[currentUser?.role]}</p>
            <p>Institution: {institution?.name}</p>
        </div>
    )
}

export default ProfileContent;