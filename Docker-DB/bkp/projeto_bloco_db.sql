--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: alunos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.alunos (
    aluno_id uuid NOT NULL,
    nome text NOT NULL,
    matricula integer NOT NULL
);


ALTER TABLE public.alunos OWNER TO postgres;

--
-- Name: alunos_matricula_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.alunos ALTER COLUMN matricula ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.alunos_matricula_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: disciplinas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.disciplinas (
    disciplina_id uuid NOT NULL,
    nome text NOT NULL,
    numero_aulas smallint NOT NULL
);


ALTER TABLE public.disciplinas OWNER TO postgres;

--
-- Name: inscricoes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.inscricoes (
    inscricao_id uuid NOT NULL,
    ativa boolean NOT NULL,
    presenca smallint NOT NULL,
    nota_p1 numeric(3,2) NOT NULL,
    nota_p2 numeric(3,2) NOT NULL,
    nota_pf numeric(3,2) NOT NULL,
    aluno_id uuid NOT NULL,
    turma_id uuid NOT NULL
);


ALTER TABLE public.inscricoes OWNER TO postgres;

--
-- Name: professores; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.professores (
    professor_id uuid NOT NULL,
    nome text NOT NULL
);


ALTER TABLE public.professores OWNER TO postgres;

--
-- Name: turmas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.turmas (
    turma_id uuid NOT NULL,
    professor_id uuid,
    disciplina_id uuid
);


ALTER TABLE public.turmas OWNER TO postgres;

--
-- Data for Name: alunos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.alunos (aluno_id, nome, matricula) FROM stdin;
8f016314-24ed-4692-a283-e839cb3cf0fd	renato	1
eb10e62d-c924-4a23-9a23-7da68148a95a	bernardo	2
\.


--
-- Data for Name: disciplinas; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.disciplinas (disciplina_id, nome, numero_aulas) FROM stdin;
42781c25-558d-4764-b741-9f2f8c8cace6	fisica	10
e4964eab-bab9-4b79-9f97-10f4213c441c	matematica	10
\.


--
-- Data for Name: inscricoes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.inscricoes (inscricao_id, ativa, presenca, nota_p1, nota_p2, nota_pf, aluno_id, turma_id) FROM stdin;
b3196ac5-01d1-4677-aeb0-4b0d925ea24b	t	1	1.00	1.00	1.00	8f016314-24ed-4692-a283-e839cb3cf0fd	8e70b445-1dfe-462e-b421-038c40cbe748
387bdddc-6100-499e-8668-fa623d2ef995	t	1	1.00	1.00	1.00	eb10e62d-c924-4a23-9a23-7da68148a95a	0636fe78-716a-4411-8f04-d9b6492dcc0d
\.


--
-- Data for Name: professores; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.professores (professor_id, nome) FROM stdin;
1c7f0ac3-9f09-42fe-a996-9fa23610fa9f	LP
5124765f-5e37-44ed-969c-e853fab745cc	Leo
\.


--
-- Data for Name: turmas; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.turmas (turma_id, professor_id, disciplina_id) FROM stdin;
8e70b445-1dfe-462e-b421-038c40cbe748	1c7f0ac3-9f09-42fe-a996-9fa23610fa9f	42781c25-558d-4764-b741-9f2f8c8cace6
0636fe78-716a-4411-8f04-d9b6492dcc0d	5124765f-5e37-44ed-969c-e853fab745cc	e4964eab-bab9-4b79-9f97-10f4213c441c
\.


--
-- Name: alunos_matricula_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.alunos_matricula_seq', 2, true);


--
-- Name: alunos alunos_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alunos
    ADD CONSTRAINT alunos_pk PRIMARY KEY (aluno_id);


--
-- Name: disciplinas disciplinas_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.disciplinas
    ADD CONSTRAINT disciplinas_pkey PRIMARY KEY (disciplina_id);


--
-- Name: inscricoes inscricoes_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inscricoes
    ADD CONSTRAINT inscricoes_pk PRIMARY KEY (inscricao_id);


--
-- Name: professores professores_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professores
    ADD CONSTRAINT professores_pkey PRIMARY KEY (professor_id);


--
-- Name: turmas turmas_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.turmas
    ADD CONSTRAINT turmas_pk PRIMARY KEY (turma_id);


--
-- Name: inscricoes inscricoes_ref_alunos_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inscricoes
    ADD CONSTRAINT inscricoes_ref_alunos_fk FOREIGN KEY (aluno_id) REFERENCES public.alunos(aluno_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: inscricoes inscricoes_ref_turmas_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inscricoes
    ADD CONSTRAINT inscricoes_ref_turmas_fk FOREIGN KEY (turma_id) REFERENCES public.turmas(turma_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: turmas turmas_ref_disciplinas_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.turmas
    ADD CONSTRAINT turmas_ref_disciplinas_fk FOREIGN KEY (disciplina_id) REFERENCES public.disciplinas(disciplina_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: turmas turmas_ref_professores_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.turmas
    ADD CONSTRAINT turmas_ref_professores_fk FOREIGN KEY (professor_id) REFERENCES public.professores(professor_id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- PostgreSQL database dump complete
--

