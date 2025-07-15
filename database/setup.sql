-- Script de criação do banco de dados para o Sistema de Cadastro de Livros
-- Execute este script no seu cliente MySQL antes de rodar a aplicação

-- Criar o banco de dados
CREATE DATABASE IF NOT EXISTS aulas;

-- Usar o banco de dados
USE aulas;

-- Criar a tabela de livros
CREATE TABLE IF NOT EXISTS livros (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    autor VARCHAR(255) NOT NULL,
    editora VARCHAR(255) NOT NULL,
    ano INT NOT NULL,
    isbn VARCHAR(50) NOT NULL,
    genero VARCHAR(100) NOT NULL
);

-- Inserir alguns dados de exemplo (opcional)
INSERT INTO livros (titulo, autor, editora, ano, isbn, genero) VALUES
('Dom Casmurro', 'Machado de Assis', 'Editora Ática', 1899, '978-85-08-12345-6', 'Romance'),
('O Cortiço', 'Aluísio Azevedo', 'Editora Moderna', 1890, '978-85-16-12345-7', 'Naturalismo'),
('Iracema', 'José de Alencar', 'Editora Saraiva', 1865, '978-85-02-12345-8', 'Romance'),
('O Guarani', 'José de Alencar', 'Editora FTD', 1857, '978-85-32-12345-9', 'Romance'),
('Memórias Póstumas de Brás Cubas', 'Machado de Assis', 'Editora Ática', 1881, '978-85-08-12346-0', 'Romance');

-- Verificar se os dados foram inseridos
SELECT * FROM livros;

-- Mostrar a estrutura da tabela
DESCRIBE livros;
