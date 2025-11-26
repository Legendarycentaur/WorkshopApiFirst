export interface Book {
  title: string;
  author: string;
  isbn: string;
  year: number;
}

export interface CreateBookDto {
  title: string;
  author: string;
  isbn: string;
  year: number;
}

export interface UpdateBookDto {
  title?: string;
  author?: string;
  year?: number;
}

// export interface BookQueryParameters {
//   author?: string;
//   year?: number;
// }

// export interface PaginatedResponse<T> {
//   data: T[];
//   pagination: {
//     page: number;
//     pageSize: number;
//     totalCount: number;
//     totalPages: number;
//   };
// }
