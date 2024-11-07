import React, { useState, useContext } from 'react';
import { useGetAllUsers } from '../greatergradesapi/Auth';
import { UserContext } from '../functions/UserContext';
import { addTeacherToClass } from '../greatergradesapi/Classes';

const AddTeacherToClassPopup = ({ onClose, courseId }) => {
    const [selectedTeacher, setSelectedTeacher] = useState('');
    const [error, setError] = useState('');
    const { currentUser, authToken } = useContext(UserContext);
    var users = useGetAllUsers();
    users = users.filter(user => user.institutionId === currentUser.institutionId);
    

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!selectedTeacher) {
            setError('Please select a teacher to add.');
            return;
        }

        try {
            await addTeacherToClass(courseId, selectedTeacher, authToken);
            onClose();
        } catch (err) {
            setError('Failed to add teacher to class.');
            console.error(err);
        }
    };

    return (
        <div className="popup-overlay">
            <div className="popup">
                <h2>Add Teacher to Class</h2>
                <form onSubmit={handleSubmit}>
                    <div>
                        <label htmlFor="teacher">Select Teacher:</label>
                        <select
                            id="teacher"
                            value={selectedTeacher}
                            onChange={(e) => setSelectedTeacher(e.target.value)}
                        >
                            <option value="">Select a teacher</option>
                            {users.map((user) => (
                                <option key={user.userId} value={user.userId}>
                                    {user.firstName} {user.lastName}
                                </option>
                            ))}
                        </select>
                    </div>
                    {error && <p className="error">{error}</p>}
                    <button type="submit">Add Teacher</button>
                    <button type="button" onClick={onClose}>Cancel</button>
                </form>
            </div>
        </div>
    );
};

export default AddTeacherToClassPopup;
