import { RoleEnum } from "../enum/Role";
import { useGetInstitutionById } from "../greatergradesapi/Institutions";
const ProfileContent = () => {
    
    const storedUser = localStorage.getItem('currentUser');
    const parsedUser = JSON.parse(storedUser);

    const institution = useGetInstitutionById(parsedUser?.institutionId)

    return (
        <div className="student-content">
            <p>First Name: {parsedUser?.firstName}</p>
            <p>Last Name: {parsedUser?.lastName}</p>
            <p>Username: {parsedUser?.username}</p>
            <p>Role: {RoleEnum[parsedUser?.role]}</p>
            <p>Institution: {institution?.name}</p>
        </div>
    )
}

export default ProfileContent;