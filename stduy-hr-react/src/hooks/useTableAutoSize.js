import { useState, useEffect } from "react";

/**
 * 테이블 컨테이너 높이에 맞게 스크롤 높이를 변경한다.
 * @param {AntTableRef} tableRef AntD 테이블 레퍼런스
 */

export function useTableAutoSize(tableRef) {
    const [scrollHeight, setScrollHeight] = useState(0);

    /** 페이지네이션 영역 높이 */
    const PAGINATION_HEIGHT = 32;

    useEffect(() => {
        const resizeScrollHeight = () => {
            const { height } = tableRef.current.getBoundingClientRect();
            const headerHeight = document.getElementsByClassName("ant-table-header")[0]
                .offsetHeight;

            setScrollHeight(height - headerHeight - PAGINATION_HEIGHT);
        };

        if (document.readyState === 'complete') {
            resizeScrollHeight();
        } else {
            window.addEventListener('load', resizeScrollHeight);
            // 클린업 함수
            return () => window.removeEventListener('load', resizeScrollHeight);
        }
    }, [tableRef])

    return scrollHeight;
};