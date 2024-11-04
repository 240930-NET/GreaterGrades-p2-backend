import { RoleEnum } from "../enum/Role";
import { getStorageItem } from "../functions/functions";
const Header = () => {
    const currentUser = getStorageItem('currentUser')

    return (
        <div className="student-header">
            <div className="student-info">
                <h3>{currentUser?.firstName} {currentUser?.lastName}</h3>
                <p>{currentUser?.username}</p>
                <p>{RoleEnum[currentUser?.role]}</p>
            </div>
        </div>
    );
};



export default Header;