import { getStorageItem } from "../functions/functions";
import Tiles from "./Tiles";
const EnrolledClasses = () => {

    const currentUser = getStorageItem('currentUser')


    return (
        <div className="student-content">
            <div>
                <h3>Enrolled Classes</h3>
                <div className="student-tiles">
                    <Tiles courseIds={currentUser?.classIds} />
                </div>
            </div>
        </div>
    )
}

export default EnrolledClasses;