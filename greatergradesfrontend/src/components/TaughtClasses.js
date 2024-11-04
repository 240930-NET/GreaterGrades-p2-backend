import { getStorageItem } from "../functions/functions";
import Tiles from "./Tiles";

const TaughtClasses = () => {
    const currentUser = getStorageItem('currentUser')


    return (
        <div className="student-content">
            <div>
                <h3>Taught Classes</h3>
                <div className="student-tiles">
                    <Tiles courseIds={currentUser?.taughtClassIds} />
                </div>
            </div>
        </div>
    )
}

export default TaughtClasses;