import { useEffect, useState } from "react";

const url = 'http://localhost:5000/api/Grades/'
const getCommonHeader = (token) => ({
    headers: {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
    },
});

export const useGetGrades = () => {
    const [grades, setGrades] = useState([])

    useEffect(() => {
        const token = localStorage.getItem('authToken');
        const fetchGrades = async () => {
            try {
                const response = await fetch(`${url}`, getCommonHeader(token));
                const data = await response.json();
                setGrades(data || [])
            } catch {
                console.error('Error fetching grades');
            }
        }
        if (token) fetchGrades();
    }, [])
    return grades;
}


export const useGetGrade = (id) => {
    const [grade, setGrade] = useState({})

    useEffect(() => {
        const token = localStorage.getItem('authToken');
        const fetchGrade = async () => {
            try {
                const response = await fetch(`${url}${id}`, getCommonHeader(token));
                const data = await response.json();
                setGrade(data || {})
            } catch {
                console.error('Error fetching grade');
            }
        }
        if (token && id) fetchGrade();
    }, [id])
    return grade;
}


export const useUpdateGrade = (id, score, gradingStatus) => {
    useEffect(() => {
        const token = localStorage.getItem('authToken');
        const fetchUpdateGrade = async () => {
            try {
                const response = await fetch(`${url}${id}`, {
                    method: 'PUT',
                    headers: {
                        'Authorization': `Bearer ${token}`,
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ score, gradingStatus })
                })
                if (response.status !== 204) throw new Error();
            } catch {
                console.error('Failed to update user');
            }
        }
        if (token && id && score && gradingStatus) fetchUpdateGrade();
    }, [id, score, gradingStatus])
}