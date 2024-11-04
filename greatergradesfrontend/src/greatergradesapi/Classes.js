import { useEffect, useState, useContext } from "react";
import { UserContext } from '../functions/UserContext';

const url = 'http://localhost:5000/api/Classes/'
const getCommonHeader = (token) => ({
    headers: {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
    },
});


export const useGetAllClasses = () => {
    const [classes, setClasses] = useState([]);
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchClasses = async () => {
            try {
                const response = await fetch(`${url}`, getCommonHeader(authToken))
                const data = await response.json();
                setClasses(data || [])
            } catch {
                console.error("Failed to fetch classes")
            }
        }
        if (authToken) fetchClasses();
    }, [authToken])
    return classes;
}


export const useAddClass = (subject, institutionId) => {
    const [course, setCourse] = useState({});
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchAddClass = async () => {
            try {
                const response = await fetch(`${url}`, {
                    method: 'POST',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ subject, institutionId })
                })
                const data = await response.json();
                setCourse(data || {})
            } catch {
                console.error("Error adding class")
            }
        }
        if (authToken && subject && institutionId) fetchAddClass();
    }, [authToken, subject, institutionId])
    return course;
}


export const useGetClassById = (id) => {
    const [course, setCourse] = useState({});
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchClass = async () => {
            try {
                const response = await fetch(`${url}${id}`, getCommonHeader(authToken))
                const data = await response.json();
                setCourse(data || {});
            } catch {
                console.error("Error fetching class");
            }
        }
        if (authToken && id) fetchClass();
    }, [authToken, id]);
    return course;
}


export const useUpdateClass = (id, subject) => {
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchUpdateClass = async () => {
            try {
                const response = await fetch(`${url}${id}`, {
                    method: 'PUT',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ subject })
                })
                if (response.status !== 204) throw new Error();
            } catch {
                console.error("Error updating class");
            }
        }
        if (authToken && id && subject) fetchUpdateClass();
    }, [authToken, id, subject])
}


export const useDeleteClass = (id) => {
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchDeleteClass = async () => {
            try {
                const response = await fetch(`${url}${id}`, {
                    method: 'DELETE',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    },
                })
                if (response.status !== 204) throw new Error();
            } catch {
                console.error("Error deleting class");
            }
        }
        if (authToken && id) fetchDeleteClass();
    }, [authToken, id])
}


export const useAddStudentToClass = (id, studentId) => {
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchAddStudentToClass = async () => {
            try {
                const response = await fetch(`${url}${id}/students/${studentId}`, {
                    method: 'POST',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    },
                })
                if (response.status !== 204) throw new Error();
            } catch {
                console.error("Error adding student to class")
            }
        }
        if (authToken && id && studentId) fetchAddStudentToClass();
    }, [authToken, id, studentId])
}


export const useDeleteStudentFromClass = (id, studentId) => {
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchDeleteStudentFromClass = async () => {
            try {
                const response = await fetch(`${url}${id}/students/${studentId}`, {
                    method: 'DELETE',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    },
                })
                if (response.status !== 204) throw new Error();
            } catch {
                console.error("Error adding student to class")
            }
        }
        if (authToken && id && studentId) fetchDeleteStudentFromClass();
    }, [authToken, id, studentId])
}


export const useAddTeacherToClass = (id, teacherId) => {
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchAddTeacherToClass = async () => {
            try {
                const response = await fetch(`${url}${id}/teachers/${teacherId}`, {
                    method: 'POST',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    },
                })
                if (response.status !== 204) throw new Error();
            } catch {
                console.error("Error adding teacher to class")
            }
        }
        if (authToken && id && teacherId) fetchAddTeacherToClass();
    }, [authToken, id, teacherId])
}


export const useDeleteTeacherFromClass = (id, teacherId) => {
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchDeleteTeacherFromClass = async () => {
            try {
                const response = await fetch(`${url}${id}/teachers/${teacherId}`, {
                    method: 'DELETE',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    },
                })
                if (response.status !== 204) throw new Error();
            } catch {
                console.error("Error adding teacher to class")
            }
        }
        if (authToken && id && teacherId) fetchDeleteTeacherFromClass();
    }, [authToken, id, teacherId])
}

//// Fetches not specifially tied to a single endpoint

export const useGetUsersClasses = (ids) => {
    const [classes, setClasses] = useState([]);
    const { authToken } = useContext(UserContext);
    
    useEffect(() => {
        const fetchCourses = async () => {
            try {
                const responses = await Promise.all(
                    ids.map(id => 
                        fetch(`${url}${id}`, getCommonHeader(authToken))
                    )
                )
                const data = await Promise.all(responses.map(res => {
                    if (!res.ok) throw new Error();
                    return res.json();
                }))
                setClasses(data);
            } catch {
                console.error("Error fetching classes")
            }
        }
        if (authToken && ids?.length > 0) fetchCourses();
    }, [authToken, ids])

    return classes;
}